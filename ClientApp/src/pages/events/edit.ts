import {LogManager, View, autoinject} from "aurelia-framework";
import {RouteConfig, NavigationInstruction, Router} from "aurelia-router";
import {EventService} from "../../services/events-service";
import {IEvent} from "../../interfaces/IEvent";
import {IAdministrativeUnit} from "../../interfaces/IAdministrativeUnit";
import {AdministrativeUnitService} from "../../services/administrativeunit-service";
import {ILocation} from "../../interfaces/ILocation";
import {LocationService} from "../../services/locations-service";
import {IEventType} from "../../interfaces/IEventType";
import {EventTypeService} from "../../services/eventtype-service";

export var log = LogManager.getLogger('Event.Edit');

@autoinject
export class Edit {

  private event: IEvent | null = null;
  private administrativeUnitList: IAdministrativeUnit[];
  private locationList: ILocation[];
  private eventTypeList: IEventType[];

  constructor(
    private router: Router,
    private eventService: EventService,
    private locationService: LocationService,
    private administrativeUnitService: AdministrativeUnitService,
    private eventTypeService: EventTypeService
  ) {
    log.debug('constructor');
  }

  // ============ View Methods ==============
  submit():void{
    log.debug('event', this.event);
    this.event.administrativeUnits = this.administrativeUnitList;
    this.event.locations = this.locationList;
    this.event.eventTypes = this.eventTypeList;
    this.eventService.put(this.event!).then(
      response => {
        if (response.status == 204){
          this.router.navigateToRoute("EventsIndex");
        } else {
          log.error('Error in response!', response);
        }
      }
    );
  }


  // ============ View LifeCycle events ==============
  created(owningView: View, myView: View) {
    log.debug('created');
  }

  bind(bindingContext: Object, overrideContext: Object) {
    log.debug('bind');
  }

  attached() {
    log.debug('attached');
  }

  detached() {
    log.debug('detached');
  }

  unbind() {
    log.debug('unbind');
  }

  // ============= Router Events =============
  canActivate(params: any, routerConfig: RouteConfig, navigationInstruction: NavigationInstruction) {
    log.debug('canActivate');
  }

  activate(params: any, routerConfig: RouteConfig, navigationInstruction: NavigationInstruction) {
    log.debug('activate', params);

    this.eventService.fetch(params.id).then(
      event => {
        log.debug('event', event);
        this.event = event;
      }
    );
    this.administrativeUnitService.fetchAll().then(
      jsonData => {
        log.debug('jsonData', jsonData);
        this.administrativeUnitList = jsonData;
      }
    );
    this.locationService.fetchAll().then(
      jsonData => {
        log.debug('jsonData', jsonData);
        this.locationList = jsonData;
      }
    );

    this.eventTypeService.fetchAll().then(
      jsonData => {
        log.debug('jsonData', jsonData);
        this.eventTypeList = jsonData;
      }
    );
  }

  canDeactivate() {
    log.debug('canDeactivate');
  }

  deactivate() {
    log.debug('deactivate');
  }
}
