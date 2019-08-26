import React from 'react';
import './Content.css'
import RoomsInfoBlock from './RoomsInfoBlock'

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
        this.setState({ page: <RoomsInfoBlock/> });
    }

    render() {

        return (
            <div className="content">
                <div className="margin"></div>
                {this.state.page}
            </div>
        )
    }
}

export default Content;