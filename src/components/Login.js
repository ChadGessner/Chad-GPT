import React, {useState} from 'react';
import Classes from './Login.module.css';
import Header from './Header'
import { useCookies } from 'react-cookie'

const uri = 'https://localhost:7185/api/User/Login/';
const Login = () => {
    const [userName, setUserName] = useState('');
    const [password, setPassword] = useState('');
    const [loggedInUser, setLoggedInUser] = useState('');
    const [cookieUser, setUser] = useCookies(["user"])
    const userLogin = (e) => {
        console.log(userName + " " + [password])
        const userData = {
            method: 'POST',
            headers: {
                'Content-Type' : 'application/json'
            },
            body: JSON.stringify({
                UserName: userName,
                Password: password
            })
        }
        return userData;
    }
    const postLogin = async() => {
        const response = await fetch(uri, userLogin())
        const data = await response.json();
        const user = data;
        if(data) {
            setLoggedInUser(user)
            setUser('user', loggedInUser, { path: '/'})
        }
        
    }
    return( 
        <div>
            <Header user={cookieUser.user ? cookieUser.user : null} ></Header>
            <div>
                <form className={Classes.form} >
                    <label className={Classes.label} >
                        Username:
                    </label>
                    <input 
                    className={Classes.input}
                    type="text" 
                    value={userName} 
                    onChange={(e)=> setUserName(e.target.value)}/>
                    <label className={Classes.label} >
                        Password:
                    </label>
                    <input 
                    className={Classes.input}
                    type="password" 
                    value={password} 
                    onChange={(e)=> setPassword(e.target.value)}/>
                    
                </form>
                <button type="submit" onClick={()=>postLogin()}>Login</button>
            </div>
        </div>
        
    )
}

export default Login;