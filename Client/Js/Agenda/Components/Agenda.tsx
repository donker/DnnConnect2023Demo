import * as React from 'react';
import { IItem } from '../Models/IItem';
import { IAppModule } from '../Models/IAppModule';
import { IPagedList } from '../Models/IPagedList';
import { IVenue } from '../Models/IVenue';
import { ICategory } from '../Models/ICategory';

interface IAgendaProps {
  module: IAppModule;
  detailUrl: string;
  cities: string[];
  categories: ICategory[];
  venues: IVenue[];
};

const Agenda: React.FC<IAgendaProps> = props => {
  const [items, setItems] = React.useState<IItem[]>([]);
  const [category, setCategory] = React.useState<number>(-1);
  const [city, setCity] = React.useState<string>("");
  const [searchText, setSearchText] = React.useState<string>("");

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
            <label htmlFor="category">{props.module.resources.Category}</label>
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
            <label htmlFor="city">{props.module.resources.City}</label>
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
            <label htmlFor="city">{props.module.resources.Search}</label>
            <input
              id="search"
              className="form-control"
              value={searchText}
              onChange={e => setSearchText(e.target.value)}
            />
          </div>
        </div>
      </div>
      <div className="row">
        <div className="col-sm-12">
          {items.map((i, j) => (
            <div className="panel panel-default">
              <div className="panel-heading">
                <h4 className="panel-title">{i.Title}</h4>
              </div>
              <div className="panel-body">
                <h6 className="card-subtitle mb-2 text-muted">{i.City}, {i.VenueName}</h6>
                <p className="card-text">{i.Description}</p>
              </div>
            </div>
          ))}
        </div>
      </div>
    </div>
  );
}

export default Agenda;