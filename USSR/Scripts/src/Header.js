import React from 'react';
import './Header.css'

class Header extends React.Component {
    constructor(props) {
        super(props)
    }

    render() {
        return (
            <div className="header">
                <div className="content">
                    <div className="logo"></div>
                    <div className="menu">
                        <ul className="up">
                            <li><a href="#">FAQ</a></li>
                            <li><a href="#">Связаться с нами</a></li>
                        </ul>
                        <ul className="down">
                            <li><a href="#">Наши квесты</a></li>
                            <li><a href="#">Информация о группе</a></li>
                        </ul>
                    </div>
                </div>
            </div>
              
        )
    }
}

export default Header;