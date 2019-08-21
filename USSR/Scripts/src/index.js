import React from 'react';
import ReactDOM from 'react-dom';

class Hello extends React.Component {
    constructor(props){
        super(props)
        this.state={
            users:[]
        }
    }

    componentDidMount(){
        fetch("/Home/GetUsers")
        .then(response=>response.json())
        .then(result=>this.setState({users:result}));
    }

    render() {
        const users = this.state.users;
        return (
            <h2>asdddd</h2>
        )
    }
}

ReactDOM.render(
    <Hello />,
    document.getElementById("root")
);