import {IBaseEntity} from "./IBaseEntity";
import {IAdministrativeUnit} from "./IAdministrativeUnit";
import {ILocation} from "./ILocation";
import {IEventType} from "./IEventType";
import {IOrganization} from "./IOrganization";
import {IAreaOfInterest} from "./IAreaOfInterest";
import {IPerformer} from "./IPerformer";
import {ITargetAudience} from "./ITargetAudience";

export interface IEvent extends IBaseEntity {
  name: string;
  description: string;
  administrativeUnits: IAdministrativeUnit[];
  locations: ILocation[];
  eventTypes: IEventType[];
  organizations: IOrganization[];
  areaOfInterests: IAreaOfInterest[];
  performers: IPerformer[];
  targetAudiences: ITargetAudience[];
  imageSrc: string;
  image: any;
  eventDate: any;


}
