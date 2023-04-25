import React from 'react';
import { Outlet, Link } from 'react-router-dom';
import Classes from './Header.module.css';
import { useCookies } from 'react-cookie';

const Header = (props) => {
    const [cookieUser, setUser] = useCookies(["user"])
    let welcomeMessage = 'Welcome to Chad GPT!'
    if(props.user) {
        
        welcomeMessage += ' ' + cookieUser.user.userName;
    }
    

    return(
            
            <nav className={Classes.nav}>
                <div className={Classes.header}>
                    <h3>{welcomeMessage}</h3>
                </div>
                <div className={Classes.links}>

                
                    <div >
                        <a >
                            <Link to="/login">Login</Link>
                        </a>
                    </div>
                    <div>
                        <a>
                        <Link to="/register">Register</Link>
                        </a>
                    </div>
                    <div>
                        <a>
                        <Link to="/form">Form</Link>
                        </a>
                    </div>
                    <div >
                        <a >
                            <Link to="/Images">Images</Link>
                        </a>
                    </div>
                </div>
            </nav>
        
    )
}

export default Header;