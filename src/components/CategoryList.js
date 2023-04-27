import React, {useState} from 'react';
import './CategoryList.css';

const CategoryList = (props) => {
    let list = []
    const [catState, setCatState] = useState({
        selectedCategory: {
            name: '',
            description: ''
        }
    })
    if(props.categoryList){
        list = props.categoryList;
    }
    const setCategory = (e) => {
        console.log(e.target.value)
        setCatState(
            catState.selectedCategory = props.categoryList[e.target.value]
        )
        props.selectedCategory(catState.selectedCategory)
    }
    return (
        <div>
            <label>Select Category</label>
        <select
        onClick={(e)=>setCategory(e)}
        className="select">
        {list.map(
            (cat, index)=>(
                <option
                key={index}
                
                value={index}
                >{cat.name}
                </option>))}
        
        </select>
        </div>
        
    )
}
export default CategoryList