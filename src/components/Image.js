
import React, {useState} from 'react';

const Image = (props) => {
    const imageUrl = props.imageUrl
    const [content, setContent] = useState('');
    if(imageUrl){
        return (
            <div>
                <img 
                height="256px"
                width="256px"
                src={props.imageUrl}/>
            </div>
        )
    }else{
        return(
            <div>
                <p>Enter an image prompt...</p>
            </div>
        )
    }
}
export default Image;