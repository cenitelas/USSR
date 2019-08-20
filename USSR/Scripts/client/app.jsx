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
        <div>
            {
                users.map(item=>
                    <h1 key={item.Id}>{item.Name}</h1>
                )
            }
        </div>
        )
    }
}

ReactDOM.render(
    <Hello />,
    document.getElementById("content")
);