import React from 'react'


const UserDetail = ({ detailType, detail }) => {
    return (
        <div className='userdetail'>
            <h3>{detailType}: {detail}</h3>
        </div>
    )
}

export default UserDetail