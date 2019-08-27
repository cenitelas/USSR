import React from 'react';
import LoginForm from './LoginForm'
import Header from './Header'
import Content from './Content'
import Footer from './Footer'
import './Main.css'

class Main extends React.Component {
    constructor(props) {
        super(props)
        this.state={
            page:'',
            key:0
        }
        this.setPage = this.setPage.bind(this);
    }

    setPage(page) {
        this.setState({key:this.state.key+1});
        this.setState({ page:page });

    }

    render() {
        return (
            <div className="main">
                <Header setPage={this.setPage}/>
                <Content key={this.state.key} page={this.state.page} setPage={this.setPage}/>
                <Footer/>
            </div>
        )
    }
}

export default Main;