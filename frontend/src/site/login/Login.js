import React, { useState } from 'react';
import { Button, Form, Label, Input, Alert, Spinner } from 'reactstrap';
import { login } from '../../services/AuthenticationService';
import './login.css';

export default function Login() {
    const [email, setEmail] = useState('');
    const [password, setPassword] = useState('');
    const [loading, setLoading] = useState(false);
    const [unauthorized, setUnauthorized] = useState(false);
    const [loginErrors, setLoginErrors] = useState(null);

    async function handleLogin(event) {
        event.preventDefault();
        setLoginErrors(null);
        setLoading(true);

        try {
            await login(email, password);
            setUnauthorized(false);
        } catch (error) {
            if (error.response?.status === 401) {
                setUnauthorized(true);
            } else {
                setLoginErrors(error.message);
            }
        }

        setLoading(false);
    }

    return (
        <div className="d-flex vh-100">
            <div className="d-flex w-100 justify-content-center align-self-center">
                <Form className="form-signin text-center" onSubmit={handleLogin}>
                    <h1 className="mb-3 font-weight-normal">Please sign in</h1>
                    {loginErrors && <Alert color="warning">{loginErrors}</Alert>}
                    {unauthorized && <Alert color="danger">Invalid e-mail or password.</Alert>}
                    <Label for="email" className="sr-only">
                        Email address
                    </Label>
                    <Input
                        required
                        type="email"
                        id="email"
                        placeholder="Email address"
                        className="form-control"
                        onChange={(event) => setEmail(event.target.value)}
                    />
                    <Label for="password" className="sr-only">
                        Password
                    </Label>
                    <Input
                        required
                        type="password"
                        id="password"
                        placeholder="Password"
                        className="form-control"
                        onChange={(event) => setPassword(event.target.value)}
                    />
                    <Button type="submit" color="primary" size="lg" block className="mt-3" disabled={loading}>
                        {loading ? (
                            <Spinner color="light" style={{ width: '1.25rem', height: '1.25rem' }} />
                        ) : (
                            'Sign in'
                        )}
                    </Button>
                </Form>
            </div>
        </div>
    );
}
