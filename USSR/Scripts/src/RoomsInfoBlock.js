import React from 'react';
import './RoomsInfoBlock.css'
import RoomInfo from './RoomInfo'

class Main extends React.Component {
    constructor(props) {
        super(props)
        this.state = {
            roomsInfo:[]
        }
    }

    componentDidMount() {
        fetch('/Home/GetRoosInfo')
            .then(request => request.json())
            .then(result => this.setState({ roomsInfo: result }));
    }

    render() {
        const roomsInfo = this.state.roomsInfo;
        return (
            <div className="rooms-info-block">
                {roomsInfo.map(item =>
                    <RoomInfo room={item}/>
                 )}
            </div>
        )
    }
}

export default Main;