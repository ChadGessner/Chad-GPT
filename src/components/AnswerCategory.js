import React, { useState, useEffect } from 'react';
import { useCookies } from 'react-cookie';

const uri = 'https://localhost:7185/api/QandA/GetQuestionByCategory'
const AnswerCategory = (props) => {
    const [content, setContent] = useState('')
    const [cookie, setCookie, removeCookie] = useCookies(["categoryList"])
    const [questionsCookie, setQuestionsCookie] = useCookies(["questions"])
    //const [cookie, setCookie, removeCookie] = useCookies(["categoryList"]);
    
    let cats;
    
    if(cookie.questions && cookie.categoryList){
        const q = questionsCookie.questions;
        console.log(q)
        for(let i = 0; i < q.length; i++){
            console.log(q[i]);
        }
        cats = cookie.categoryList.filter(
            x => q.some(t => x.id === t.categoryId)
        );
        
    }else{
       cats = null;
    }
    


        // add component listing questions per category...
    return (
        <div>
            <ul>
                {cats &&
                   cats.map(
                    (x,i)=>(
                        <li key={x} >{x.name}</li>
                    )
                   )}
            </ul>
        </div>
    )

}

export default AnswerCategory;