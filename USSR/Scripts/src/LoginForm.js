import React from 'react';
import App from './App';
import ReactDOM from 'react-dom';

class LoginForm extends React.Component {
    constructor(props) {
        super(props);
        this.state = {
            login: '', password: '', rePassword:'', isReg:props.isReg, message:''
        };
   
        this.onChangeLogin = this.onChangeLogin.bind(this);
        this.onChangePassword = this.onChangePassword.bind(this);
        this.onChangeRePassword = this.onChangeRePassword.bind(this);
        this.onSubmit = this.onSubmit.bind(this);
    }

    onSubmit(event) {
        var state = this;
        if (!this.state.isReg) {
            var data = new FormData();
            data.append("Name", this.state.login);
            data.append("Pass", this.state.password);

            fetch('/Home/Login', {
                method: 'POST',
                body: data
            }).then(response => response.json())
                .then(function (result) {
                    if (result.Id === 0) {
                        state.setState({ message: "Неверное имя пользователя или пароль!" })
                    } else {
                        ReactDOM.render(
                            <App user={result} />,
                            document.getElementById("root")
                        );
                    }
                });
        } else {
            if (this.state.password === this.state.rePassword) {
                var data = new FormData();
                data.append("Name", this.state.login);
                data.append("Pass", this.state.password);

                fetch('/Home/Reg', {
                    method: 'POST',
                    body: data
                }).then(response => response.json())
                    .then(function (result) {
                        if (result.Id === 0) {
                            state.setState({ message: "Пользователь существует!" })
                        } else {
                                ReactDOM.render(
                                    <App user={result} />,
                                    document.getElementById("root")
                                );
                            
                        }
                    }
                    );
            } else {
                this.setState({ message: "Пароли не совпадают!" })
            }
        }
        event.preventDefault();
    }

    onChangePassword(event) {
        this.setState({ password: event.target.value });
    }

    onChangeRePassword(event) {
        this.setState({ rePassword: event.target.value });
    }

    onChangeLogin(event) {
        this.setState({ login: event.target.value });
    }

    render() {
            return (
                <form onSubmit={this.onSubmit}>
                    <p><label> Логин: <input type="text" name="login" value={this.state.login}
                        onChange={this.onChangeLogin} /></label></p>
                    <p><label> Пароль: <input type="password" name="password" value={this.state.password}
                        onChange={this.onChangePassword} /></label></p>
                    {this.state.isReg &&
                        <p><label> Повторить пароль: <input type="password" name="rePassword" value={this.state.rePassword}
                            onChange={this.onChangeRePassword} /></label></p>
                    }
                    <p><input type="submit" value="Submit" /></p>
                    <p>{this.state.message}</p>
                </form>
            );
    }
}

export default LoginForm;