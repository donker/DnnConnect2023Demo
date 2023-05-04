import * as React from 'react';
import { IAppModule } from '../Models/IAppModule';
import { IItem, Item } from '../Models/IItem';
import { ICategory } from '../Models/ICategory';
import { IVenue } from '../Models/IVenue';

interface IEditItemProps {
  module: IAppModule;
  categories: ICategory[];
  venues: IVenue[];
  itemUnderEdit: IItem | null;
  updateItem: (item: IItem) => void;
  cancelEdit: () => void;
};

const EditItem: React.FC<IEditItemProps> = props => {
  const [item, setItem] = React.useState<IItem>(new Item());
  React.useEffect(() => {
    if (props.itemUnderEdit) setItem(props.itemUnderEdit);
  }, [props.itemUnderEdit]);

  if (props.itemUnderEdit === null) return (<div></div>);

  return (
    <div className="modal show">
      <div className="modal-dialog">
        <div className="modal-content">
          <div className="modal-header">
            <button
              type="button"
              className="close"
              aria-label="Close"
              onClick={(e) => { e.preventDefault(); props.cancelEdit() }}
            ><span aria-hidden="true">&times;</span></button>
            <h4 className="modal-title">Edit Item</h4>
          </div>
          <div className="modal-body">
            <div className="form-group">
              <label>Title</label>
              <input
                className="form-control"
                value={item.Title || ""}
                onChange={e => setItem({ ...item, Title: e.target.value })}
              />
            </div>
            <div className="form-group">
              <label>Description</label>
              <input
                className="form-control"
                value={item.Description || ""}
                onChange={e => setItem({ ...item, Description: e.target.value })}
              />
            </div>
            <div className="form-group">
              <label>Venue</label>
              <select
                className="form-control"
                value={item.Venue}
                onChange={e => setItem({ ...item, Venue: parseInt(e.target.value) })}
              >
                <option value="-1">Select a venue</option>
                {props.venues.map((v, i) => (
                  <option key={i} value={v.VenueId}>{v.VenueName}, {v.City}</option>
                ))}
              </select>
            </div>
            <div className="form-group">
              <label>Category</label>
              <select
                className="form-control"
                value={item.Category}
                onChange={e => setItem({ ...item, Category: parseInt(e.target.value) })}
              >
                <option value="-1">Select a category</option>
                {props.categories.map((c, i) => (
                  <option key={i} value={c.CategoryId}>{c.CategoryName}</option>
                ))}
              </select>
            </div>
            <div className="form-group">
              <label>Date From</label>
              <input
                type="date"
                className="form-control"
                value={(item.DateFrom || "").substring(0, 10)}
                onChange={e => setItem({ ...item, DateFrom: e.target.value })}
              />
            </div>
            <div className="form-group">
              <label>Date To</label>
              <input
                type="date"
                className="form-control"
                value={(item.DateTo || "").substring(0, 10)}
                onChange={e => setItem({ ...item, DateTo: e.target.value })}
              />
            </div>
          </div>
          <div className="modal-footer">
            <button
              type="button"
              className="btn btn-default"
              onClick={(e) => { e.preventDefault(); props.cancelEdit() }}
            >Close</button>
            <button
              type="button"
              className="btn btn-primary"
              disabled={item.Title === "" || item.Description === "" || item.Venue === -1 || item.Category === -1 || item.DateFrom === "" || item.DateTo === ""}
              onClick={(e) => { e.preventDefault(); props.updateItem(item) }}
            >Save changes</button>
          </div>
        </div>
      </div>
    </div>
  );
}

export default EditItem;