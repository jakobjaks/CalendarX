import {LogManager, View, autoinject} from "aurelia-framework";
import {RouteConfig, NavigationInstruction, Router} from "aurelia-router";
import {AreaOfInterestService} from "../../services/areaofinterests-service";
import {IAreaOfInterest} from "../../interfaces/IAreaOfInterest";

export var log = LogManager.getLogger('ContactTypes.Details');

@autoinject
export class Details {

  private areaOfInterest: IAreaOfInterest | null = null;

  constructor(
    private router: Router,
    private areaOfInterestService: AreaOfInterestService
  ) {
    log.debug('constructor');
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
    this.areaOfInterestService.fetch(params.id).then(
      areaOfInterest => {
        log.debug('contactType', areaOfInterest);
        this.areaOfInterest = areaOfInterest;
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
