import React, { useRef } from 'react';
import { Editor } from '@tinymce/tinymce-react';
import classes from './Form.module.css';


const key = 'd848zvk8dob626a8emj2tf0ny4f1zp3cuc32hyfmdmk75fg9';
const magicHTMLRegex =  "/<\/?!?(img|a)[^>]*>/g";
const bsRegex = "/<p>&nbsp;</p>/"
const tagRegex = "/(<p>)|(<\/p>)|(&nbsp;)/g"
const Form = () => {
    let currentQuestion = '';
    const editorRef = useRef(null);
    const log = () => {
        
        if(editorRef.current){
            console.log(editorRef.current.getContent());
        }
    };
    const handleEditorChange = (e) => {
        console.log('Content was updated:', e.target.getContent())
        //currentQuestion = e.target.getContent().match(magicHTMLRegex)
        //currentQuestion = e.target.getContent().toString()
        currentQuestion = e.target.getContent().toString();
        let cleaned = currentQuestion.replace(/(<p>)|(<\/p>)|(&nbsp;)|(\\n+$)/g,"")
        //console.log(currentQuestion.match(tagRegex))
        console.log(cleaned)
    }
    //missing 'print' and 'paste' plugins

    return (
        <div className={classes.stuff}>
            <h2>Welcome to CHAD GPT ask me anything!</h2>
            <Editor
             
            apiKey={key}
            onInit={(evt, editor) => editor.current = editor}
            initialValue="<p>Where are we?</p>"
            init={{
                height: 500,
                width: '80%',
                
                menubar: false,
                // plugins: [
                //     'advlist',
                //     'autolink',
                //     'lists',
                //     'link',
                //     'image',
                //     'charmap',
                    
                //     'preview',
                //     'anchor',
                //     'searchreplace',
                //     'visualblocks',
                //     'code',
                //     'fullscreen',
                //     'insertdatetime',
                //     'media',
                //     'table',
                    
                //     'help',
                //     'wordcount'
                    
                //   ],
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
            
            <button >Log editor content</button>
            
        </div>
    )
}

export default Form;