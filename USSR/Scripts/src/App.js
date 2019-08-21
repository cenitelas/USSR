import React from 'react';

class App extends React.Component {
    constructor(props) {
        super(props);
        this.state = {
            user: props.user
        }
    }



    render() {
        return (
            <div>
                <p>{this.state.user.Name}</p>
                <p>{this.state.user.Id}</p>
            </div>
           )
        }
    }

    export default App;