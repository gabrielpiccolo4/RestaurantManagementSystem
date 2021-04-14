import React from 'react';
import PropTypes from 'prop-types';
import { Label, Input, FormFeedback } from 'reactstrap';

export default class InputWithValidation extends React.Component {
    render() {
        const {
            id,
            placeholder,
            onChange,
            label,
            labelClassName,
            inputClassName,
            errorMessage,
            ...inputProps
        } = this.props;

        return (
            <React.Fragment>
                <Label for={id} className={labelClassName}>
                    {labelClassName === 'sr-only' ? placeholder : label}
                </Label>
                <Input
                    id={id}
                    placeholder={placeholder}
                    className={inputClassName}
                    onChange={(event) => onChange(event.target.value)}
                    invalid={errorMessage ? true : false}
                    {...inputProps}
                />
                {errorMessage && <FormFeedback>{errorMessage}</FormFeedback>}
            </React.Fragment>
        );
    }
}

InputWithValidation.propTypes = {
    onChange: PropTypes.func.isRequired,
    label: PropTypes.string,
    labelClassName: PropTypes.string,
    inputClassName: PropTypes.string,
    errorMessage: PropTypes.string
};

InputWithValidation.defaultProps = {
    labelClassName: 'sr-only',
    inputClassName: 'form-control'
};
