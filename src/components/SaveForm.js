import React, {useState, useEffect } from 'react';
import { useCookies } from 'react-cookie';
import './SaveForm.css'

const uri = 'https://localhost:7185/api/QandA/'
const SaveForm = (props) => {
    //const selectRef = useRef(null)
    const [cookieUser, setUser] = useCookies(["user"])
    const [formState, setFormState] = useState({
        question: props.question,
        answer: props.answer,
        selectedCategory: {
            id: -1,
            name: '',
            description: '',
        },
        createdCategory: {
            name: '',
            description: ''
        },
        user: {
            id: -1,
            userName: '',
            password: '',
            email: '',
            created: new Date().getDate()
        },
        categoryList: [{
            id: -1,
            name: 'stuff',
            description: 'things'
        }]
    })
    useEffect(async()=>{
        const response = await fetch(uri + 'GetQuestionCategories',{})
        const json = await response.json();
        if(json){
            setFormState(
            (prev)=>{
                const newData = {...prev}
                newData.categoryList = json;
                return newData;
            });
        }else{
            setFormState(
                (prev)=>{
                    const newData = {...prev};
                    return newData;
                }
            )
        }
        
    }, [])
    // const setCategoryList = async() => {
    //     await setFormState(
    //         getCategoryList()
    //     )
    //     return formState.categoryList;
    // }
    const setNameCategory = (e) => {
        setFormState(
            (prev)=>{
                const data = {...prev};
                data.createdCategory.name = e.target.value;
                return data;
            }
        )
    }
    const setCategoryDescription = (e) => {
        setFormState(
            (prev)=>{
                const data = {...prev};
                data.createdCategory.description = e.target.value;
                return data
            }
        )
    }
    const setFormQuestion = (e) => {
        setFormState(
            (prev)=>{
                const newState = {...prev}
                newState.question = e.target.value
                return newState
            }
        )
    }
    const setFormAnswer = (e) => {
        const answer = e.target.value
        setFormState(
            (prev)=>{
                const newState = {...prev}
                newState.answer = answer
                return newState;
            }
            
        )
    }
    const setCategory = (e) => {
        setFormState(
            (prev)=> {
                const newState = {...prev}
                newState.selectedCategory = e
                return newState
            }
        )
    }
    
    const postCategory = async(e) => {
        e.preventDefault();
        console.log(formState.createdCategory)
        const response = await fetch(uri + 'PostCategory',{
            method: 'POST',
            headers: {
                'Content-Type' : 'application/json'
            },
            body: JSON.stringify(formState.createdCategory)
        })
        const json = response.json();
        console.log(json);
        return json;
    }
    const getCategoryList = async() => {
        const response = await fetch(uri + 'GetQuestionCategories', {})
        const json = response.json();
        console.log(json)
        return json;
    }
    return(
        <div className="card" >
             <div className="card">
                <form 
                onSubmit={(e)=>postCategory(e)}  
                className="form" >
                    <label className="label">
                        Category Name
                    </label>
                    <input 
                    onChange={(e)=>setNameCategory(e)}
                    value={formState.createdCategory.name}/>
                    <label className="label">
                        Category Description
                    </label>
                    <input 
                    onChange={(e)=>setCategoryDescription(e)}
                    value={formState.createdCategory.description}/>
                    <button type="submit" >Submit New Category</button>
                </form>
            </div>

            <div className="card">
                <form className="form" >
                    <label className="label" >
                        Question
                    </label>
                    <input 
                    onChange={(e)=> setFormQuestion(e)} 
                    value={formState.question} type="text"/>
                    <label className="label" >
                        Answer
                    </label>
                    <input 
                    onChange={(e)=> setFormAnswer(e)} 
                    value={formState.answer} type="text"/>
                    <label className="label" >
                        Category
                    </label>
                    <select 
                    
                    className="select">
                        {formState.categoryList.map(
                                (cat)=>(
                                    <div
                                    onClick={(e)=> setCategory(cat)}
                                    key={cat}
                                    >{cat.name}</div>))}
                        
                    </select>
                    <button>Submit New Question</button>
                </form>
            </div>
        </div>
    )
}
export default SaveForm;