import React, { useState} from 'react';
import './App.css';
import AnswerList from './components/AnswerList'
import Form from './components/Form';
const uri = 'https://localhost:7185/api/ChadGPT/AskChadGPT/';

const question = 'What are the four fundamental pillars of OOP?';

function App() {
  const [answers, setAnswers] = useState([]);
  const [isLoading, setIsLoading] = useState(false);
  
  
  const fetchAnswer = async() => {
    setIsLoading(true);
    const response = await fetch(uri + question,{});
    const data = await response.json();
    //const answerAnswer = data.value;
    const newAnswer = [data.value].map((m)=>{
      return {
        id: answersArray.length + 1,
        question: question,
        answer: m}
    })
    
    setAnswers(newAnswer)
    if(answersArray){
      answersArray.concat(answers)
    }
    console.log(answersArray)
    setIsLoading(false)
  }
  let answersArray = [{
    id: 0,
    question: 'how do?',
    answer: '...'
  }];
  
  
  
    return (
      

      <React.Fragment>
      <section>
        < button onClick={fetchAnswer} >Answers</button>
      </section>
      <section>
        {!isLoading && <AnswerList answers={answers} />}
        {isLoading && <div>loading...</div>}
      </section>
      <Form></Form>
      </React.Fragment>
      // <React.Fragment>
    // </React.Fragment>
    );
  
  
}

export default App;
