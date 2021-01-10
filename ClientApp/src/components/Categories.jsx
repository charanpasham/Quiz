import React, { Component } from "react";
import authService from "./api-authorization/AuthorizeService";

export class Categories extends Component {
  constructor(props) {
    super(props);
    this.state = { categories: null, userId: null };
  }

  componentDidMount = () => {
    this.populateCategories();
  };

  render() {
    let { categories, userId } = this.state;
    let renderCategories = categories
      ? categories.map((cat) => <div>{cat.quizCategoryType}</div>)
      : null;
    return (
      <div>
        <h1>Categories</h1>
        {renderCategories}
        {userId}
      </div>
    );
  }

  async populateCategories() {
    const { sub } = await authService.getUser();
    const response = await fetch("/api/quiz/category", {
      method: "GET",
      "Content-Type": "application/json",
    });
    const data = await response.json();
    this.setState({ categories: data, userId: sub });
  }
}
