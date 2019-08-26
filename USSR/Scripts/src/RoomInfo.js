import React from 'react';
import './RoomInfo.css'
import {Button} from 'react-bootstrap'
import asd from '../img/room1.jpg'
class RoomInfo extends React.Component {
    constructor(props) {
        super(props)
        this.state = {
            roomInfo : props.room
        }
    }

    render() {
        const room = this.state.roomInfo;
        const roomImg =require('../img/'+room.UrlImage);
        return (
            <div className="room-info">             
                <div className="logo">
                <div className="room-stat">
                    <p>{room.MinUsers}-{room.MaxUsers} participans</p>
                    <p>{room.Delay} mins.</p>
                    <p>{room.EscapeRate}%</p>
                </div>
                     <img src={roomImg}/>
                </div>
               
                <h3>{room.Name}</h3>
                <p>{room.Discription}</p>
                <Button variant="outline-warning">BOOK NOW</Button>
            </div>
        )
    }
}

export default RoomInfo;