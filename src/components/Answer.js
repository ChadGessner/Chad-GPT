import React from 'react';
import classes from './Answer.module.css'

const Answer = (props) => {
    console.log(props)
    return(
        <li className={classes.answer}>
            <h2>{props.question}</h2>
            <h3>{props.answer}</h3>
        </li>
    )
}
export default Answer;