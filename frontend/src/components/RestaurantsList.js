import React, { useEffect, useState } from 'react';
import api from '../services/Api';
import { Table } from 'reactstrap';

export default function RestaurantsList() {
    const [loading, setLoading] = useState(true);
    const [restaurants, setRestaurants] = useState([]);

    useEffect(() => {
        async function fetchData() {
            const response = await api.get('Restaurant');
            setRestaurants(response.data);
            setLoading(false);
        }

        fetchData();
    }, []);

    function renderRestaurantsTable() {
        return (
            <Table>
                <thead>
                    <tr>
                        <th>Name</th>
                        <th>Address</th>
                        <th>Rating</th>
                    </tr>
                </thead>
                <tbody>
                    {restaurants.map((restaurant) => (
                        <tr key={1}>
                            <td>{restaurant.name}</td>
                            <td>{restaurant.address}</td>
                            <td>{restaurant.rating}</td>
                        </tr>
                    ))}
                </tbody>
            </Table>
        );
    }

    return (
        <div>
            <h1>Restaurants</h1>
            <div>{loading ? 'Loading in progress...' : renderRestaurantsTable()}</div>
        </div>
    );
}
