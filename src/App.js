import React, { useState, useEffect } from 'react';
import {BrowserRouter as Router, Route, Routes, BrowserRouter } from 'react-router-dom';

import './App.css';
import AnswerList from './components/AnswerList'
import Form from './components/Form';
import Header from './components/Header';
import Login from './components/Login';
import Register from './components/Register';
import Images from './components/Images'
import { useCookies, CookiesProvider } from 'react-cookie';
const uri = 'https://localhost:7185/api/ChadGPT/AskChadGPT/';
const categoryUri = 'https://localhost:7185/api/QandA/';
const getAllQuestionsUri = 'https://localhost:7185/api/QandA/GetAllQuestions';

function App() {
  const [answers, setAnswers] = useState([]);
  const [isLoading, setIsLoading] = useState(false);
  const [cookie, setCookie, removeCookie] = useCookies(["categoryList"]);
  const [userCookie, setUserCookie] = useCookies(["user"])
  const [questionsCookie, setQuestionsCookie, removeQuestions] = useCookies()
  const fetchSomeData = async() => {

      const response = await fetch(categoryUri + 'GetQuestionCategories',{})
      const json = await response.json();
      if(json) {
        cookieChange(json, 'categoryList')
      }
      console.log(cookie.categoryList)
    }
    const cookieChange = async(data, cookieName) =>{
      return await setCookie(
        cookieName,
        data,
        { path: '/'}
      )
    }
  useEffect(()=>{
    
    //fetchSomeData();
    fetchAllAnswers();
    return ()=>{}
  },[])
  // useEffect(()=>{



  //   return ()=>{}
  // },[])
  const fetchAllAnswers = async() => {
    const response =  await fetch(getAllQuestionsUri,{});
    const json = await response.json();
    if(json){
      
      setAnswers(
        json
      )
      cookieChange(json,'questions')
    }
    console.log(answers)
    console.log(cookie["questions"])
  }
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
          <CookiesProvider>
          <Routes>
            <Route path="/" element={<Header/>}/>
            <Route path="/login" element={<Login/>}/>
            <Route path="/register" element={<Register/>}/>
            <Route path="/form" element={<Form/>}/>
            <Route path="/images" element={<Images/>}/>
          </Routes>

          </CookiesProvider>


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
