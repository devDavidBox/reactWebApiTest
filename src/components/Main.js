import React from 'react';
// import '../styles/Main.scss';

class Main extends React.Component {
    constructor() {
        super();
        this.state = {
            message: "Test"
        }
    }

    render() {
        <div>
            <div>Hello World!</div>
            <p>This website is designed to help in creating music. {this.state.message}</p>
        </div>
    }
}

export default Main;