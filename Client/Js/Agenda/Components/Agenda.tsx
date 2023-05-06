import * as React from 'react';

interface IAgendaProps {
  moduleId: number;
};

const Agenda: React.FC<IAgendaProps> = props => {
  return (
    <div className="container-fluid">
      <div className="row">
        Hello React {props.moduleId}
      </div>
    </div>
  );
}

export default Agenda;