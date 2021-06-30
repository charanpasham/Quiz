import React, { useState, useEffect } from "react";
import authService from "./api-authorization/AuthorizeService";

  function Categories()  {

  const [categoryName, setCategoryName] = useState('');
  const [listOfCategoryNames, setListOfCategoryNames] = useState([]);
  const [errorMessage, setErrorMessage] = useState('');

  useEffect(() => {
    async function fetchData(){
      const response = await fetch("/api/quiz/category", {
        method: "GET",
        "Content-Type": "application/json",
      });
      const data = await response.json();
      setListOfCategoryNames(data);
    }
    fetchData();
  });

   const postData = async (url = '', data = {}, method = "GET") => {
      const response = await fetch(url, {
        method,
        headers: {
          'Content-Type': 'application/json'
        },
        body: JSON.stringify(data),
      });
      return response.json();
    };

   const submitCategory = async (e) => {
     setErrorMessage('');
     e.preventDefault();
   if(categoryName.length > 0) {
     const data = {
       quizCategoryType: categoryName,
     }
    await postData("/api/quiz/category", data, "POST");
   } else {
      setErrorMessage('Categary name should not be empty and should be unique!')
   }
  };

  const deleteCategory = async (categoryId) => {
    if(categoryId) {
      await postData(`/api/quiz/deleteCategory/${categoryId}`, undefined, "DELETE");
    }
  }

    let categoryForm = (
      <form>
        <label htmlFor='categoryName'>Category Name:</label>
        <input type="text" id='categoryName' value={categoryName} onChange={e => setCategoryName(e.target.value)} />
        <input type="submit" value="submit" onClick={e => submitCategory(e)} />
      </form>
    )
    let renderCategories = listOfCategoryNames
      ? listOfCategoryNames.map(
          (category) =>
           <>
            <div key={category.quizCategoryId}>{category.quizCategoryType}
            <button onClick={() => deleteCategory(category.quizCategoryId)}>
              X
            </button>
            </div>
          
          </>
          )
      : null;



    return (
      <div>
        <h1>Categories</h1>
        {categoryForm}
        <span style={{ color: 'red' }}>{errorMessage} </span>
        {renderCategories}
      </div>
    );
  }

  export default Categories;