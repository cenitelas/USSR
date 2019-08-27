import React from 'react';
import './Content.css'
import RoomsInfoBlock from './RoomsInfoBlock'

class Content extends React.Component {
    constructor(props) {
        super(props)
        this.state = {
            user: {},
            page: props.page,
            setPage: props.setPage
        }
    }

    componentDidMount() {
        if(this.state.page===''){
            var context = <RoomsInfoBlock setPage={this.state.setPage}/>;
            this.setState({page:context});
        }
    }

    render() {
        console.log(this.state.page);
        return (
            <div className="content">
                <div className="margin"></div>
                {this.state.page}
            </div>
        )
    }
}

export default Content;