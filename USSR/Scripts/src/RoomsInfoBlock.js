import React from 'react';
import './RoomsInfoBlock.css'
import RoomInfo from './RoomInfo'

class Main extends React.Component {
    constructor(props) {
        super(props)
        this.state = {
            roomsInfo:[],
            setPage:props.setPage
        }
    }

    componentDidMount() {
        fetch('/Home/GetRoomsInfo')
            .then(request => request.json())
            .then(result => this.setState({ roomsInfo: result }));
    }

    render() {
        const roomsInfo = this.state.roomsInfo;
        return (
            <div className="rooms-info-block">
                <div className="rooms-info-block-header">Все комнаты побега</div>
                <div className="rooms-info-block-content">
                        {roomsInfo.map(item =>
                            <RoomInfo setPage={this.state.setPage} key={item.id} room={item}/>
                        )}
                 </div>
            </div>
        )
    }
}

export default Main;