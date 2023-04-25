import React, {useState} from "react";
import Classes from './Register.module.css'
import Header from './Header'
import { useCookies } from "react-cookie";
const uri = 'https://localhost:7185/api/User/Register/';
const Register = () => {
    const [userName, setUserName] = useState('');
    const [password, setPassword] = useState('');
    const [email, setEmail] = useState('');
    const [cookieUser, setUser] = useCookies(["user"])
    const register = async() => {
        
    const requestData= {
        method: 'POST',
        headers: {
            'Content-Type' : 'application/json'
        },
        body: JSON.stringify({
        id:0,
        userName: userName,
        password: password,
        email: email
    
        })
    }
        
        const response = await fetch( uri, requestData)
        const data = await response.json();
        const registeredUser = data.value;
        
    }

    return(
        <div>
            <Header user={cookieUser.user} />
        
            <div>
                <form className={Classes.form} >
                    <label className={Classes.label} >
                        Username:
                    </label>
                    <input 
                    className={Classes.input} 
                    type="text" value={userName} 
                    onChange={(e)=> setUserName(e.target.value)} />
                    <label className={Classes.label} >
                        Password:
                    </label>
                    <input 
                    className={Classes.input}  
                    type="text" value={password} 
                    onChange={(e)=> setPassword(e.target.value)} />
                    <label className={Classes.label} >
                        Email:
                    </label>
                    <input 
                    className={Classes.input}  
                    type="text" value={email} 
                    onChange={(e)=> setEmail(e.target.value)} />
                
                </form>
        
                <button onClick={()=>register()} type="submit">Register!</button>
            </div>
        </div>
    )
}

export default Register;