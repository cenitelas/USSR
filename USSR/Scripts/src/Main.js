import React from 'react';
import LoginForm from './LoginForm'
import Header from './Header'
import Content from './Content'
import Footer from './Footer'
import './Main.css'

class Main extends React.Component {
    constructor(props) {
        super(props)
    }

    render() {
        return (
            <div className="main">
                <Header/>
                <Content/>
                <Footer/>
            </div>
        )
    }
}

export default Main;