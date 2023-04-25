
import React, {useState} from 'react';
import { useCookies} from 'react-cookie';
import { dummyImage } from '../DummyImage.module';
import  Classes from './Login.module.css'
import Header from './Header'
import Image from './Image'
const uri = 'https://localhost:7185/api/Image/ImagePrompt/';
const Images = () => {
    const [content, setContent] = useState('');
    const [cookieUser, setUser] = useCookies(["user"]);
    const [cookieImage, setImage] = useCookies(['image']);
    let imageUrl = null;
    let imagePrompt = content;
    // const userPost = (e)=>{
    //     const data = {
    //         method: 'POST',
    //         headers: {
    //             'Content-Type' : 'application/json'
    //         },
    //         body: JSON.stringify({

    //         })
    //     }
    // }
    const renderImage = (e)=>{
        if(e){
            return imagePrompt;
        }else{
            return null;
        }
    } 
    const postImage = async(e) => {
        const response = await fetch(uri + content, {
            method: 'POST',
            headers: {
                'Content-Type' : 'application/json'
            },
            body: JSON.stringify(
                cookieUser
            )
        });
        const data = await response.json();
        const image = data;
        if(data) {
            imageUrl = image.data[0].url;
            return renderImage(e);
        }
    }

    return(
        <div>
            <Header user={cookieUser.user ? cookieUser.user : null} ></Header>
            <div>
                
                <Image imageUrl={imageUrl}/>
                <form className={Classes.form} >
                    <label className={Classes.label} >
                        Image Prompt:
                    </label>
                    <input 
                    className={Classes.input}
                    type="text" 
                    value={imagePrompt} 
                    onChange={(e)=> setContent(e.target.value)}/>
                    
                    
                </form>
                <button type="submit" onClick={(e)=>postImage(e)}>Login</button>
            </div>
        </div>
    )
}
export default Images;