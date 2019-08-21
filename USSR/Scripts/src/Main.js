import React from 'react';
import LoginForm from './LoginForm'

class Main extends React.Component {
    constructor(props) {
        super(props)
        this.state = { isReg: false }
        this.onClickLog = this.onClickLog.bind(this);
        this.onClickReg = this.onClickReg.bind(this);
    }

    onClickReg(e) {
        this.setState({ isReg: true });
    }

    onClickLog() {
        this.setState({ isReg: false });
    }

    render() {
        return (
            <div>
                <button onClick={this.onClickLog}>Авторизация</button>
                <button onClick={this.onClickReg}>Регистрация</button>
                {this.state.isReg === true &&
                    <LoginForm isReg={true} />
                }
                {this.state.isReg===false &&
                    <LoginForm isReg={false} />
                }
            </div>
        )
    }
}

export default Main;