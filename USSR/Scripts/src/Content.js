import React from 'react';
import './Content.css'

class Content extends React.Component {
    constructor(props) {
        super(props)
        this.state = {
            user: {},
            page: ''
        }
        this.getPage = this.getPage.bind(this);
    }

    componentDidMount() {
        this.getPage();
    }

    getPage() {
        this.setState({ page: <h3>dddd</h3> });
    }

    render() {

        return (
            <div className="content">
                {this.state.page}
            </div>
        )
    }
}

export default Content;