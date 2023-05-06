import * as React from 'react';
import { IItem } from '../Models/IItem';
import { IAppModule } from '../Models/IAppModule';
import { IPagedList } from '../Models/IPagedList';

interface IAgendaProps {
  module: IAppModule;
  detailUrl: string;
};

const Agenda: React.FC<IAgendaProps> = props => {
  const [items, setItems] = React.useState<IItem[]>([]);

  React.useEffect(() => {
    getItems();
  }, []);

  const getItems = () => {
    props.module.service.getItems(-1, "", "", "DateFrom", "ASC", 25, 0, (data: IItem[]) => {
      setItems(data);
    });
  }

  return (
    <div className="container-fluid">
      <div className="row">
        <div className="col-12">
          <h1>Agenda</h1>
          <p>
            {items.length} items found.
          </p>
        </div>
      </div>
    </div>
  );
}

export default Agenda;