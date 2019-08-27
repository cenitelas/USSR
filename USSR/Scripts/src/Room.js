import React from 'react';
import './Room.css'

class Room extends React.Component {
    constructor(props) {
        super(props)
        this.state = {
            room : props.room,
            setPage : props.setPage
        }
    }

    render() {
        const room = this.state.room;
        const roomImg =require('../img/'+room.UrlImage);
        return (
            <div>             
                <h3>{room.Name}</h3>
                <p>{room.Discription}</p>
            </div>
        )
    }
}

export default Room;