import React from 'react';
import LoginForm from './LoginForm'
import Header from './Header'
import './Main.css'

class Main extends React.Component {
    constructor(props) {
        super(props)
        this.state = { isReg: false }
    }

    render() {
        return (
            <div className="main">
                <Header className="header"/>
                <h1>asdasd</h1>
            </div>
        )
    }
}

export default Main;