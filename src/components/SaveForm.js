import React, {useState, useEffect } from 'react';
import { useCookies } from 'react-cookie';
import './SaveForm.css'
import CategoryList from './CategoryList'
const uri = 'https://localhost:7185/api/QandA/'
const SaveForm = (props) => {
    let categoryList = []
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
        categoryList: []
    })
    
    const postQuestion = async(event) => {
        event.preventDefault()
        console.log(cookieUser["question"])
        if(cookieUser && props.question && props.answer && formState.selectedCategory){
            const questionPostModel = {
                user: cookieUser.user,
                question: {
                    question: props.question,
                    answer: props.answer
                },
                category: formState.selectedCategory
            }
            const response = await fetch(uri + 'PostAnswer',{
                method: 'POST',
                headers: {
                    'Content-Type' : 'application/json'
                },
                body: JSON.stringify(questionPostModel)
            })
            const json = await response.json;
            if(json){
                console.log(json);
                console.log("fuck maybe?!")
            }
            
        }
        console.log(formState)
    }
    const isRender = formState.categoryList.length !== 0;
    useEffect(()=>{
        console.log(cookieUser.answer)
        console.log(cookieUser.question)
        getCategoryList()
        return ()=>{}
    }, [])
    const setCategoryList = async() => {
        return getCategoryList();
    }
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
        console.log(e)
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
        const json = await response.json();
        console.log(json);
        return json;
    }
    const getCategoryList = async() => {
        const response = await fetch(uri + 'GetQuestionCategories', {})
        const json = await response.json();
        setFormState(
            (prev)=>{
                const newData = {...prev};
                newData.categoryList = json
                return newData;
            }
        )
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
                <form 
                onSubmit={postQuestion}
                className="form" >
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
                    
                    <button type="submit" >Submit New Question</button>
                </form>
            </div>
            <div className='card'>
                {
                    formState.categoryList.length > 0 &&
                    <CategoryList selectedCategory={
                        (e)=>setCategory(e)} 
                        categoryList={formState.categoryList} ></CategoryList>
                }
                
            </div>
        </div>
    
    )
}
export default SaveForm;