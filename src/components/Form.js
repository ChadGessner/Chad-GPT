import React, { useRef, useState } from 'react';
import { Editor } from '@tinymce/tinymce-react';
import classes from './Form.module.css';
import Header from './Header';
import { useCookies} from 'react-cookie';
import SaveForm from './SaveForm'
// ################# Check if this works ##################
import { tinymceKey } from '../Secrets/keys.module';
const key = tinymceKey;
// ################# Check if this works ##################


const urls = {
    qAndA: 'https://localhost:7185/api/QandA/',
    askCGPT: 'https://localhost:7185/api/ChadGPT/AskChadGPT/'
}
const Form = () => {
    
    const [cookieUser, setUser] = useCookies(["user"])
    const [content, setContent] = useState('')
    let currentQuestion = '';
    const editorRef = useRef(null);

    const getCategories = async() => {
        const response = await fetch(urls.qAndA + 'GetQuestionCategories', {})
        const json = response.json();
        console.log(json)
        
        return [...json]
    }

    const log = () => {
        
        if(editorRef.current){
            console.log(editorRef.current.getContent());
        }
    };
    const handleEditorChange = (content, editor) => {
        
        setContent(content)
    }
    
    const sendRequest = async(e) => {
        const editor = window.tinymce.get('ask-chad-gpt')
        const question = editor.getContent();
        const response = await fetch(urls.askCGPT + question,{});
        const data = await response.json();
        const answerAnswer = data.value;
        const newContent = question +  answerAnswer;
        editor.setContent(newContent);
    }
    //missing 'print' and 'paste' plugins

    return (
        <div className={classes.stuff}>
            
            <Header user={cookieUser.user} />
            <SaveForm categoryList={getCategories} user={cookieUser.user}/>
            <h2>Welcome to CHAD GPT ask me anything!</h2>
            <button onClick={(e)=>sendRequest(e)}>Get Answers!</button>
            <Editor
             id={'ask-chad-gpt'}
            apiKey={key}
            onInit={(evt, editor) => editor.current = editor}
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
            
            }onChange={(e)=>handleEditorChange(e)}/>
            
            
            
        </div>
    )
}

export default Form;