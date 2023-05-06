import * as React from 'react';

interface IAgendaProps {
  moduleId: number;
  detailUrl: string;
};

const Agenda: React.FC<IAgendaProps> = props => {
  return (
    <div className="container-fluid">
      <div className="row">
        <div className="col-12">
          <h1>Agenda</h1>
          <p>
            <a href={props.detailUrl.replace("-1", "1")}>Detail Example</a>
          </p>
        </div>
      </div>
    </div>
  );
}

export default Agenda;