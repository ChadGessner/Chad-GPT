import React, {useState } from 'react';




const SaveForm = (props) => {
    const [formState, setFormState] = useState({
        question: '',
        answer: '',
        category: '',
        user: {
            id: -1,
            userName: '',
            password: '',
            email: '',
            created: new Date().getDate()
        }
    })
    const answer = props.answer;
    const question = props.question;
    const categoryList = props.categoryList;

    return(
        <div>
            <form>
                <label>
                    Question
                </label>
                <input value={question} type="text"/>
                <label>
                    Answer
                </label>
                <input value={answer} type="text"/>
                <label>
                    Category
                </label>
                <select type="text" value={categoryList}>
                    {
                        categoryList.map(
                            (cat,index)=>{
                                <option
                                key={index}
                                value={cat.name}/>
                            }
                        )
                    }
                </select>
            </form>
        </div>
    )
}
export default SaveForm;