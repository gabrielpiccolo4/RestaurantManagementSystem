import React from 'react';
import PropTypes from 'prop-types';
import { Button, Spinner } from 'reactstrap';

export default class ButtonWithLoading extends React.Component {
    render() {
        const { loading, text, ...buttonProps } = this.props;

        return (
            <Button disabled={loading} {...buttonProps}>
                {loading ? <Spinner color="light" style={{ width: '1.25rem', height: '1.25rem' }} /> : text}
            </Button>
        );
    }
}

ButtonWithLoading.propTypes = {
    loading: PropTypes.bool,
    text: PropTypes.string.isRequired
};

ButtonWithLoading.defaultProps = {
    loading: false
};
