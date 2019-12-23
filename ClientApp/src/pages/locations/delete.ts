import {LogManager, View, autoinject} from "aurelia-framework";
import {RouteConfig, NavigationInstruction, Router} from "aurelia-router";
import {LocationService} from "../../services/locations-service";
import {ILocation} from "../../interfaces/ILocation";

export var log = LogManager.getLogger('Location.Delete');

@autoinject
export class Delete {

  private Location: ILocation;

  constructor(
    private router: Router,
    private LocationService: LocationService
  ) {
    log.debug('constructor');
  }

  // ============ View Methods ==============

  submit():void{
    this.LocationService.delete(this.Location.id).then(response => {
      if (response.status == 200){
        this.router.navigateToRoute("LocationsIndex");
      } else {
        log.debug('response', response);
      }
    });
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
    this.LocationService.fetch(params.id).then(
      Location => {
        log.debug('Location', Location);
        this.Location = Location;
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
