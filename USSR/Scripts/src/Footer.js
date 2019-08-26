import React from 'react';
import './Footer.css'

class Content extends React.Component {
    constructor(props) {
        super(props)
    }

    render() {
        return (
            <div className="footer">
                <div className="up">
                        <ul>
                            <li>Главная</li>
                            <li>Наши квесты</li>
                            <li>Информация о группе</li>
                            <li>FAQ</li>
                            <li>Связаться с нами</li>
                        </ul>
                    <div className="up-footer">
                        <div className="up-left"></div>
                        <div className="up-right"></div>
                    </div>
                </div>
                <div className="down">
                    <h5>© Create by Atrchanov | All Rights Reserved</h5>
                </div>
            </div>
        )
    }
}

export default Content;