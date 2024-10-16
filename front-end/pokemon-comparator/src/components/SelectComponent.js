import React from 'react';

const SelectComponent = ({ label, options, onChange }) => {
  return (
    <div className="mb-3">
      <label className="form-label">{label}</label>
      <select className="form-select" onChange={onChange}>
        <option value="">Select Pokemon</option>
        {options.map((option) => (
          <option key={option} value={option}>{option}</option>
        ))}
      </select>
    </div>
  );
};

export default SelectComponent;
