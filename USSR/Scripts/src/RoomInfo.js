import React from 'react';
import './RoomInfo.css'

class RoomInfo extends React.Component {
    constructor(props) {
        super(props)
        this.state = {
            roomInfo : props.room
        }
    }

    render() {
        const room = this.state.roomInfo;
        return (
            <div className="room-info">
                <img src={room.img}>
            </div>
        )
    }
}

export default RoomInfo;