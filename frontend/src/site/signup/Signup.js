import React, { useState } from 'react';
import { Form, Alert } from 'reactstrap';
import InputWithValidation from '../../components/InputWithValidation';
import ButtonWithLoading from '../../components/ButtonWithLoading';
import { signup } from '../../services/AuthenticationService';
import './signup.css';

export default function Signup() {
    const [name, setName] = useState('');
    const [email, setEmail] = useState('');
    const [password, setPassword] = useState('');
    const [loading, setLoading] = useState(false);
    const [signupAlerts, setSignupAlerts] = useState(null);
    const [signupErrors, setSignupErrors] = useState({});

    async function handleLogin(event) {
        event.preventDefault();
        setSignupErrors(null);
        setLoading(true);

        try {
            await signup(name, email, password);
        } catch (error) {
            console.log('catch');

            if (error.response.data?.errors) {
                setSignupErrors(error.response.data.errors);
            } else if (error.response && error.response.status === 303) {
                setSignupAlerts('Account already exists, login instead.');
            } else {
                setSignupAlerts(error.message);
            }
        }

        setLoading(false);
    }

    return (
        <div className="d-flex vh-100">
            <div className="d-flex w-100 justify-content-center align-self-center">
                <Form className="form-signup text-center" onSubmit={handleLogin}>
                    <h1 className="mb-3 font-weight-normal">Please sign up</h1>
                    {signupAlerts && <Alert color="warning">{signupAlerts}</Alert>}
                    <InputWithValidation
                        required
                        type="text"
                        id="name"
                        placeholder="Name"
                        onChange={setName}
                        errorMessage={signupErrors?.Name}
                    />
                    <InputWithValidation
                        required
                        type="email"
                        id="email"
                        placeholder="Email address"
                        onChange={setEmail}
                        errorMessage={signupErrors?.Email}
                    />
                    <InputWithValidation
                        required
                        type="password"
                        id="password"
                        placeholder="Password (6 or more characters)"
                        onChange={setPassword}
                        errorMessage={signupErrors?.Password}
                    />
                    <ButtonWithLoading
                        text="Sign up"
                        loading={loading}
                        type="submit"
                        color="primary"
                        size="lg"
                        block
                        className="mt-3"
                    />
                </Form>
            </div>
        </div>
    );
}
