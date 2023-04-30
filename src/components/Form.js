import React, { useRef, useState } from 'react';
import { Editor } from '@tinymce/tinymce-react';
import classes from './Form.module.css';
import Header from './Header';
import AnswerCategory from './AnswerCategory';
import { useCookies} from 'react-cookie';
import SaveForm from './SaveForm'
// ################# Check if this works ##################
import { tinymceKey } from '../Secrets/keys.module';
const key = tinymceKey;
// ################# Check if this works ##################


const urls = {
    qAndA: 'https://localhost:7185/api/QandA/',
    askCGPT: 'https://localhost:7185/api/QandA/AskChadGPT/'
}
const Form = () => {
    const [cookie, setCookie] = useCookies(["user"],["question"],["answer"],["categoryList"]);
    // const [cookieQuestion, setQuestion] = useCookies(["question"]);
    // const [cookieAnswer, setAnswer] = useCookies(["answer"])
    // const [categories, setCategories] = useCookies(["categoryList"]);
    const [content, setContent] = useState('')
    let currentQuestion = '';
    const editorRef = useRef(null);

    // const getCategories = async() => {
    //     const response = await fetch(urls.qAndA + 'GetQuestionCategories', {})
    //     const json = response.json();
    //     setCategories(
    //         (prev)=>{
    //             let cats = [...prev];
    //             cats.concat([...json])
    //             return cats;
    //         }
    //     )
    //     console.log(categories)
    //     return [...json]
    // }

    const ed = (evt, editor) => {
        
        console.log(evt);
        console.log(editor);
        console.log(editor.current)
        
    }
    const handleEditorChange = (e) => {
        e.current = e.target
    }
    
    const sendRequest = async(e) => {
        console.log(e)
        let editor = await window.tinymce.get('ask-chad-gpt')
        let question = await editor.getContent();
        
        
        setContent(
            question
        )
        console.log(content)
        let response = await fetch(urls.askCGPT + question,{});
        let data = await response.json();
        let answerAnswer = data.value;
        let newContent = question +  answerAnswer;
        editor.setContent(newContent);
        setContent(
            ''
        )
    }
    //missing 'print' and 'paste' plugins

    return (
        <div className={classes.stuff}>
            
            <Header user={cookie.user} />
            <AnswerCategory categories={cookie.categories} ></AnswerCategory>
            <SaveForm  user={cookie.user}/>
            <h2>Welcome to CHAD GPT ask me anything!</h2>
            <button onClick={(e)=>sendRequest(e)}>Get Answers!</button>
            <Editor
             id={'ask-chad-gpt'}
            apiKey={key}
            onInit={(editor)=>{editor.current = editor}}
            onChange={(e)=>handleEditorChange(e)}
            initialValue="<p>Who are we and where are we going in this ocean of chaos?</p>"
            init={{
                height: 500,
                width: '80%',
                
                menubar: false,
                
                  plugins: [
                    'advlist','autolink',
                    'lists','link','image','charmap','preview','anchor','searchreplace','visualblocks',
                    'fullscreen','insertdatetime','media','table','help','wordcount'
                 ],
                  toolbar: 'undo redo | formatselect | ' +
                  'bold italic backcolor | alignleft aligncenter ' +
                  'alignright alignjustify | bullist numlist outdent indent | ' +
                  'removeformat | help',
                  content_style: 'body { font-family:Helvetica,Arial,sans-serif; font-size:14px;width:90vw; }'
                  
            }
            
            }/>
            
            
            
        </div>
    )
}

export default Form;