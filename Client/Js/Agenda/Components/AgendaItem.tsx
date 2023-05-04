import * as React from 'react';
import { IItem } from '../Models/IItem';
import { IAppModule } from '../Models/IAppModule';

interface IAgendaItemProps {
  module: IAppModule;
  item: IItem;
  detailUrl: string;
  onEdit: (item: IItem) => void;
};

const AgendaItem: React.FC<IAgendaItemProps> = props => {
  const df = new Date(props.item.DateFrom);
  return (
    <div className="panel panel-default">
      <div className="panel-heading">
        <h4 className="panel-title">{df.toLocaleDateString('en-US')} {props.item.Title}</h4>
      </div>
      <div className="panel-body">
        <h6 className="card-subtitle mb-2 text-muted">{props.item.City}, {props.item.VenueName}</h6>
        <p className="card-text">{props.item.Description}</p>
      </div>
      <div className="panel-footer">
        <a href={props.detailUrl.replace("-1", props.item.ItemId.toString())} className="btn btn-default" style={{ marginRight: "10px" }}>Details</a>
        {props.module.security.CanManage &&
          <a href="#" className="btn btn-default" onClick={(e) => {
            e.preventDefault();
            props.onEdit(props.item);
          }}>Edit</a>
        }
      </div>
    </div>
  );
}

export default AgendaItem;