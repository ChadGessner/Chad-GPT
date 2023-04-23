import React from 'react';

import Answer from './Answer';
import classes from './AnswerList.module.css';

const AnswerList = (props) => {
    console.log(props)
    return(<ul className={classes['answer-list']}>
        {props.answers.map((answer)=>(
            
            <Answer 
            key={answer.id}
            question={answer.question}
            answer={answer.answer} />


        ))}
    </ul>)
}
export default AnswerList