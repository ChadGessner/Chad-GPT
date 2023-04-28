import React, { useState, useEffect } from 'react';
import {BrowserRouter as Router, Route, Routes, BrowserRouter } from 'react-router-dom';

import './App.css';
import AnswerList from './components/AnswerList'
import Form from './components/Form';
import Header from './components/Header';
import Login from './components/Login';
import Register from './components/Register';
import Images from './components/Images'
import { useCookies } from 'react-cookie';
const uri = 'https://localhost:7185/api/ChadGPT/AskChadGPT/';
const categoryUri = 'https://localhost:7185/api/QandA/';

//const question = 'What are the four fundamental pillars of OOP?';

function App() {
  const [answers, setAnswers] = useState([]);
  const [isLoading, setIsLoading] = useState(false);
  const [cookie, setCookie] = useCookies(["categoryList"]);
  const fetchSomeData = async() => {
    console.log('stuff')
    
      const response = await fetch(categoryUri + 'GetQuestionCategories',{
      
      })
      const json = await response.json();
      if(json) {
        setCookie('categoryList', json, {path: '/'})
      }
      console.log(cookie["categoryList"])
      console.log(cookie["user"])
      
    }
  useEffect(()=>{
    fetchSomeData()
    return ()=>{}
  },[])
  // const fetchAnswer = async() => {
  //   setIsLoading(true);
  //   const response = await fetch(uri + question,{});
  //   const data = await response.json();
  //   //const answerAnswer = data.value;
  //   const newAnswer = [data.value].map((m)=>{
  //     return {
  //       id: answersArray.length + 1,
  //       question: question,
  //       answer: m}
  //   })
    
  //   setAnswers(newAnswer)
  //   if(answersArray){
  //     answersArray.concat(answers)
  //   }
  //   console.log(answersArray)
  //   setIsLoading(false)
  // }
  // let answersArray = [{
  //   id: 0,
  //   question: 'how do?',
  //   answer: '...'
  // }];
    return (
        <BrowserRouter>
          
          <Routes>
            <Route path="/" element={<Header/>}/>
            <Route path="/login" element={<Login/>}/>
            <Route path="/register" element={<Register/>}/>
            <Route path="/form" element={<Form/>}/>
            <Route path="/images" element={<Images/>}/>
          </Routes>
          
        
        
      
          </BrowserRouter>
        
      // <section>
      //   < button onClick={fetchAnswer} >Answers</button>
      // </section>
      // <section>
      //   {!isLoading && <AnswerList answers={answers} />}
      //   {isLoading && <div>loading...</div>}
      // </section>
      
      
      // <React.Fragment>
    // </React.Fragment>
    );
  
  
}

export default App;
