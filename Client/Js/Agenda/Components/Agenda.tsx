import * as React from 'react';
import { IAppModule } from '../Models/IAppModule';
import { ICategory } from '../Models/ICategory';
import { IItem, Item } from '../Models/IItem';
import { IPagedList } from '../Models/IPagedList';
import AgendaItem from './AgendaItem';
import EditItem from './EditItem';
import { IVenue } from '../Models/IVenue';

interface IAgendaProps {
  module: IAppModule;
  cities: string[];
  categories: ICategory[];
  venues: IVenue[];
  detailUrl: string;
  canEdit: boolean;
};

const Agenda: React.FC<IAgendaProps> = props => {
  const [items, setItems] = React.useState<IItem[]>([]);
  const [category, setCategory] = React.useState<number>(-1);
  const [city, setCity] = React.useState<string>("");
  const [searchText, setSearchText] = React.useState<string>("");
  const [itemUnderEdit, setItemUnderEdit] = React.useState<IItem | null>(null);

  React.useEffect(() => {
    getItems();
  }, [category, city, searchText]);

  const getItems = () => {
    props.module.service.getItems(category, city, searchText, "DateFrom", "ASC", 25, 0, (data: IPagedList<IItem>) => {
      setItems(data.data);
    });
  }

  return (
    <div className="container-fluid">
      <div className="row">
        <div className="col-sm-2">
          <div className="form-group">
            <label htmlFor="category">Category</label>
            <select
              id="category"
              className="form-control"
              value={category}
              onChange={e => setCategory(parseInt(e.target.value))}
            >
              <option value="-1">All</option>
              {props.categories.map((c, i) => (
                <option key={i} value={c.CategoryId}>{c.CategoryName}</option>
              ))}
            </select>
          </div>
        </div>
        <div className="col-sm-2">
          <div className="form-group">
            <label htmlFor="city">City</label>
            <select
              id="city"
              className="form-control"
              value={city}
              onChange={e => setCity(e.target.value)}
            >
              <option value="">All</option>
              {props.cities.map((c, i) => (
                <option key={i} value={c}>{c}</option>
              ))}
            </select>
          </div>
        </div>
        <div className="col-sm-2">
          <div className="form-group">
            <label htmlFor="city">Search</label>
            <input
              id="search"
              className="form-control"
              value={searchText}
              onChange={e => setSearchText(e.target.value)}
            />
          </div>
        </div>
        <div className="col-sm-2" style={{ paddingTop: "24px" }}>
          {props.canEdit && (
            <a href="#" className="btn btn-primary"
              onClick={e => {
                e.preventDefault();
                setItemUnderEdit(new Item());
              }}
            >Add</a>
          )}
        </div>
      </div>
      <div className="row">
        <div className="col-sm-12">
          {items.map((i, j) => (
            <AgendaItem
              key={j}
              module={props.module}
              item={i}
              detailUrl={props.detailUrl}
              onEdit={item => setItemUnderEdit(item)}
              canEdit={props.canEdit}
            />
          ))}
        </div>
      </div>
      <EditItem
        module={props.module}
        categories={props.categories}
        venues={props.venues}
        itemUnderEdit={itemUnderEdit}
        cancelEdit={() => setItemUnderEdit(null)}
        updateItem={item => {
          props.module.service.updateItem(item, () => {
            setItemUnderEdit(null);
            getItems();
          });
        }}
      />
    </div>
  );
}

export default Agenda;